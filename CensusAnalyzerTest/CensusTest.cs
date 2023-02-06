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

        //TC 1.2 Given incorrect file should return custom exception - File not found
        [Test]
        public void GivenWrongFileReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.FILE_NOT_FOUND;
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 1.3 Given correct path but incorrect file type should return custom exception - Invalid file type
        [Test]
        public void GivenWrongFileTypeReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE;
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 1.4 Given correct path but wrong delimiter should return custom exception - File Containers Wrong Delimiter
        [Test]
        public void GivenWrongDelimiterReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER;
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongDelimiterFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 1.5 Given correct path but wrong header should return custom exception - Incorrect header in Data
        [Test]
        public void GivenWrongHeaderReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCORRECT_HEADER;
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }
    }
}