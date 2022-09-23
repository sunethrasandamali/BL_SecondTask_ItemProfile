using BlueLotus360.Core.Domain.Definitions.DataLayer;
using BlueLotus360.Core.Domain.Definitions.Repository;
using BlueLotus360.Data.SQL92.DataLayer;
using BlueLotus360.Data.SQL92.Definition;
using BlueLotus360.Data.SQL92.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Data.SQL92.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Privates
        private IUserRepository _userRepository;
        private ICompanyRepository _companyRepository;
        private IAPIRepository _apiRepository;
        #endregion



        public IUserRepository UserRepository { get { 
            if( _userRepository == null)
                {
                    _userRepository = new UserRepository(_dataLayer);
                }
            return _userRepository;
            }
        }

        public IAPIRepository APIRepository
        {
            get
            {
                if (_apiRepository == null)
                {
                    _apiRepository = new APIRepository(_dataLayer);
                }
                return _apiRepository;
            }
        }

        public ICompanyRepository CompanyRepository
        {
            get
            {
                if (_companyRepository == null)
                {
                    _companyRepository = new CompanyRepository(_dataLayer);
                }
                return _companyRepository;
            }
        }

        private ISQLDataLayer _dataLayer;
        private string _connectionStrin;
        IConfiguration _configuration;

        public UnitOfWork(IConfiguration configuration)
        {
            try
            {
                var configurationSection = configuration.GetSection("ConnectionStrings:BL10DATA"); 
                if(configurationSection != null && configurationSection.Value!=null)
                {
                    _connectionStrin = configurationSection.Value;
                    _dataLayer = new SQLDataLayer(_connectionStrin);

                }
                else
                {
                    throw new InvalidOperationException("Cannot Read Data Confiuration");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ex");
            }


        }
    }
}
