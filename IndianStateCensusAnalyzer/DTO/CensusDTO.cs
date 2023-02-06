using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyzer.DTO
{
    public class CensusDTO
    {
        public int serialNumber;
        public string stateName;
        public string state;
        public int tin;
        public string stateCode;
        public long population;
        public long area;
        public long density;
        public double totalArea;
        public double waterArea;
        public double landArea;

        // Parameterized Constructor For Initializes a new instance of the class.
        public CensusDTO(StateDataDAO stateDataDAO)
        {
            this.serialNumber = stateDataDAO.serialNumber;
            this.stateName = stateDataDAO.stateName;
            this.tin = stateDataDAO.tin;
            this.stateCode = stateDataDAO.stateCode;
        }

        // Parameterized Constructor Initializes a new instance of the class.
        public CensusDTO(CensusDataDAO censusDataDAO)
        {
            this.state = censusDataDAO.state;
            this.population = censusDataDAO.population;
            this.area = censusDataDAO.area;
            this.density = censusDataDAO.density;
        }
    }
}
