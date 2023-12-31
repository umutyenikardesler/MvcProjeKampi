﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public Heading GetByID(int id)
        {
            return _headingDal.Get(x=>x.HeadingID == id);
        }

        public List<Heading> GetByCategoryID(int id)
        {
            return _headingDal.List(x=>x.CategoryID == id);
        }

        public List<Heading> GetByWriterID(int id)
        {
            return _headingDal.List(x => x.WriterID == id);
        }

        public HeadingManager(IHeadingDal headinDal)
        {
            _headingDal = headinDal;
        }

        public List<Heading> GetList()
        {
            return _headingDal.List();
        }

        public void HeadingAdd(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            if(heading.HeadingStatus == false)
            {
                heading.HeadingStatus = true;
            }
            else if(heading.HeadingStatus == true)
            {
                heading.HeadingStatus = false;
            }

            _headingDal.Update(heading);

            //_headingDal.Delete(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingDal.List(x => x.WriterID == id);
        }
    }
}
