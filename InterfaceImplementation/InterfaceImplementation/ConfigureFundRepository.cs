using System;
using System.Collections.Generic;
using System.Configuration;

namespace InterfaceImplementation
{
    class ConfigureFundRepository
    {
        public List<QueryResult> GetFundResult()
        {

            string repoName = ConfigurationManager.AppSettings["FundRepoType"];
            Type repoType = Type.GetType(repoName);
            IFundRepository Funds = Activator.CreateInstance(repoType) as IFundRepository;

            Console.WriteLine(Funds.GetType());
            List<QueryResult> result = Funds.GetRepository();
            return result;
        }

    }
}
