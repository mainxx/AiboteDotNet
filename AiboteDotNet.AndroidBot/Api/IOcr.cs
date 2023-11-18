using AiboteDotNet.AndroidBot.DataModel;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot.Api
{
    public interface IOcr
    {
        public Task<bool> InitOcr(string ocrServerIp, int ocrServerPort = 9527);
        public Task<PositionConnent> FindWords(string words);
        public Task<PositionConnent> FindContainsWords(string words);
        public Task<PositionConnent> FindWords(string words, Region region, int scale);
        public Task<PositionConnent> FindWords(string words, Region region, ThresholdTypes thresholdType, int thresh, int scale);
        public Task<List<PositionConnent>> GetWords();
        public Task<List<PositionConnent>> GetWords(Region region, int scale);
        public Task<List<PositionConnent>> GetWords(Region region, ThresholdTypes thresholdType, int thresh, int scale);

    }
}
