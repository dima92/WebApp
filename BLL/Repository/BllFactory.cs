﻿using BLL.Interfaces;
using DAL.DAL_Core.Repository;

namespace BLL.Repository
{
    public class BllFactory : IBllFactory
    {
        private readonly DalFactory _dalFactory;

        private IStorekeeperBll _storekeeperBll;
        private IDetailBll _detailBll;
        public BllFactory()
        {
            _dalFactory = new DalFactory(new DbFactory());
        }

        public IStorekeeperBll StorekeeperBll => _storekeeperBll ??= new StorekeeperBll();
        public IDetailBll DetailBll => _detailBll ??= new DetailBll();
    }
}