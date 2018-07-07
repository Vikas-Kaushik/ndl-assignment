using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contest.Models;
using Contest.Repositories;

namespace Contest.Services
{
    public class Judge : IJudge
    {
        private readonly List<(PrizeDto, Candidates)> _prizeCandidates; 

        public Judge()
        {
            _prizeCandidates = new List<(PrizeDto, Candidates)>();
        }

        public void AddPrizes(IEnumerable<PrizeDto> prizes)
        {
            foreach(var prize in prizes)
            {
                _prizeCandidates.Add((prize, new Candidates(prize.UnlockedDate)));
            }
        }

        public void Consider(ContestantDto contestant)
        {
            foreach((var prize, var candidates) in _prizeCandidates)
            {
                candidates.Update(contestant);
            }
        }

        public void SaveWinners(IWinnerRepository winnerRepository)
        {
            foreach ((var prize, var candidates) in _prizeCandidates)
            {
                ContestantDto winningContestant = candidates.GetBestCandidate();

                // There's no winner for the prize yet
                if (winningContestant is null) continue;

                WinnerDto winner = new WinnerDto(winningContestant, prize);

                winnerRepository.Write(winner);
            }
        }

        private class Candidates
        {
            // Keeps only best candidates so far
            private Dictionary<ContestantDto, int> contestantsFreqMap;
            private readonly DateTime unlockedDate;            
            private TimeSpan bestTimeYet;

            public Candidates(DateTime unlockedDate)
            {
                this.unlockedDate = unlockedDate;
                contestantsFreqMap = new Dictionary<ContestantDto, int>();
                bestTimeYet = TimeSpan.MaxValue;
            }

            internal ContestantDto GetBestCandidate()
            {
                return contestantsFreqMap.Keys.FirstOrDefault();
            }

            internal void Update(ContestantDto contestant)
            {
                // 1. If this contestant participated before unlockedDate
                //      Ignore this contestant and return
                //
                // 2. Measure contestant performance
                //
                // 3. If this contestant did better than our best yet
                //      Empty contestantsFreqMap and make this one
                // 4. Else If this contestant did as good as our best yet
                //      If contestant exists in contestantsFreqMap
                //          Increase contestant Frequency
                //          Remove all contestants who got lower frequency than current contestant
                //      Else
                //          Add the contestant to contestantsFreqMap with freq 1
                // 5. Else (this contestant did worse than our best yet)
                //      Ignore this contestant

                if (contestant.ParticipationDate < unlockedDate) return;

                var participatedAfter = contestant.ParticipationDate - unlockedDate;

                if(participatedAfter < bestTimeYet)
                {
                    contestantsFreqMap = new Dictionary<ContestantDto, int>
                    {
                        [contestant] = 1
                    };
                }
                else if(participatedAfter == bestTimeYet)
                {
                    if(contestantsFreqMap.ContainsKey(contestant))
                    {
                        RemoveAllContestatWithLesserFrequency(++contestantsFreqMap[contestant]);
                    }
                    else
                    {
                        contestantsFreqMap[contestant] = 1;
                    }
                }
            }

            private void RemoveAllContestatWithLesserFrequency(int freq)
            {
                foreach(var key in contestantsFreqMap
                    .Where(kvp => kvp.Value < freq)
                    .Select(kvp => kvp.Key)
                    .ToList())
                {
                    contestantsFreqMap.Remove(key);
                }
            }
        }
    }
}
