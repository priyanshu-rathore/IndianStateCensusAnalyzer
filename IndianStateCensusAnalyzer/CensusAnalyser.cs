using IndianStateCensusAnalyzer.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyzer
{
    public class CensusAnalyser
    {
        // enum Country Constant for diffrent country.
        public enum Country
        {
            INDIA, US
        }

        Dictionary<string, CensusDTO> dataMap;

        // Loads the census data.
        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }
    }
}
