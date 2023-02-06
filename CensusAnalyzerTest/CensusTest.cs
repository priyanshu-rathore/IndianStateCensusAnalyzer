using IndianStateCensusAnalyzer;
using IndianStateCensusAnalyzer.POCO;

namespace CensusAnalyzerTest
{
    public class CensusTest
    {
        string stateCensusFilePath = @"C:\Users\scorp\Desktop\IndianStateCensusAnalyzer\CensusAnalyzerTest\Resources\IndiaStateCensusData.csv";
        string wrongFilePath = @"C:\Users\scorp\Desktop\IndianStateCensusAnalyzer\CensusAnalyzerTest\Resources\IndiaStateCensusData.csv";
        string wrongTypeFilePath = @"C:\Users\scorp\Desktop\IndianStateCensusAnalyzer\CensusAnalyzerTest\Resources\IndiaStateCode.txt";
        string wrongDelimiterFilePath = @"C:\Users\scorp\Desktop\IndianStateCensusAnalyzer\CensusAnalyzerTest\Resources\DelimiterIndiaStateCensusData.csv";
        string wrongHeaderFilePath = @"C:\Users\scorp\Desktop\IndianStateCensusAnalyzer\CensusAnalyzerTest\Resources\WrongIndiaStateCensusData.csv";


        string stateCodeHeader = "SrNo,State Name,TIN,StateCode";
        string stateCodeFilePath = @"C:\Users\scorp\Desktop\IndianStateCensusAnalyzer\CensusAnalyzerTest\Resources\IndiaStateCode.csv";
        string wrongStateCodeFilePath = @"C:\Users\scorp\Desktop\IndianStateCensusAnalyzer\CensusAnalyzerTest\Resources\WrongFileNameIndiaStateCode.csv";
        string wrongStateCodeTypeFilePath = @"C:\Users\scorp\Desktop\IndianStateCensusAnalyzer\CensusAnalyzerTest\Resources\IndiaStateCode.txt";
        string wrongStateCodeDelimiterFilePath = @"C:\Users\scorp\Desktop\IndianStateCensusAnalyzer\CensusAnalyzerTest\Resources\DelimiterIndiaStateCode.csv";
        string wrongStateCodeHeaderFilePath = @"C:\Users\scorp\Desktop\IndianStateCensusAnalyzer\CensusAnalyzerTest\Resources\WrongIndiaStateCode.csv";

        CSVAdapterFactory csvAdapter;
        Dictionary<string, CensusDTO> stateRecords;

        [SetUp]
        public void Setup()
        {
            csvAdapter = new CSVAdapterFactory();
            stateRecords = new Dictionary<string, CensusDTO>();
        }

        //TC 1.1 Given correct path To ensure number of records matches
        [Test]
        public void GivenStateCensusCsvReturnStateRecords()
        {
            int expected = 29;
            stateRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCensusFilePath, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(expected, stateRecords.Count);
        }
    }
}