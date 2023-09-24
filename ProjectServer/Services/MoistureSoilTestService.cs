﻿using Microsoft.EntityFrameworkCore;
using ProjectServer.Data;
using ProjectServer.Interfaces.Services;
using ProjectCommon.Models;

namespace ProjectServer.Services
{
    /// <inheritdoc cref="ICustomerService"/>
    public class MoistureSoilTestService : IMoistureSoilTestService
    {
        private readonly AppDbContext _appDb;

        public MoistureSoilTestService(AppDbContext appDb)
        {
            _appDb = appDb;
        }

        public MoistureSoilTest Get(Guid moistureSoilTestId)
        {
            var moistureSoilTest = _appDb.MoistureSoilTests.Where(x => x.Id == moistureSoilTestId)
                .Include(x => x.CustomerTest)
                .Include(x => x.SoilWetMassWithBox)
                .Include(x => x.SoilDryMassWithBox)
                .Include(x => x.BoxMass)
                .Include(x => x.MoistureSoil)
                .FirstOrDefault();

            return moistureSoilTest;
        }

        public MoistureSoilTest Add(MoistureSoilTest moistureSoilTest)
        {
            moistureSoilTest.Id = Guid.NewGuid();
            moistureSoilTest.CustomerTest.Id = Guid.NewGuid();

            var entity = _appDb.MoistureSoilTests.Add(moistureSoilTest);
            _appDb.SaveChanges();

            return entity.Entity;
        }

        public bool Remove(Guid moistureSoilTestId)
        {

            var moistureSoilTest = _appDb.MoistureSoilTests
                .Where(x => x.Id == moistureSoilTestId)
                .Include(x => x.SoilWetMassWithBox)
                .Include(x => x.SoilDryMassWithBox)
                .Include(x => x.BoxMass)
                .Include(x => x.MoistureSoil)
                .FirstOrDefault();

            if (moistureSoilTest == null)
            {
                return false;
            }

            _appDb.MoistureSoilTests.Remove(moistureSoilTest);
            _appDb.SaveChanges();

            return true;
        }

        public bool Update(MoistureSoilTest moistureSoilTest)
        {
            var dbMoistureSoilTest = _appDb.MoistureSoilTests
                .AsNoTracking()
                .Where(x => x.MoistureSoilTestId == moistureSoilTest.MoistureSoilTestId)
                .Include(x => x.CustomerTest)
                .Include(x => x.SoilWetMassWithBox)
                .Include(x => x.SoilDryMassWithBox)
                .Include(x => x.BoxMass)
                .Include(x => x.MoistureSoil)
                .FirstOrDefault();

            if (dbMoistureSoilTest == null)
            {
                return false;
            }

            // Пример применения Update
            if (dbMoistureSoilTest.MoistureSoilTestId != moistureSoilTest.MoistureSoilTestId)
            {
                dbMoistureSoilTest.MoistureSoilTestId = moistureSoilTest.MoistureSoilTestId;
            }

            dbMoistureSoilTest.MaterialName = moistureSoilTest.MaterialName;
            dbMoistureSoilTest.CustomerTest = moistureSoilTest.CustomerTest;
            dbMoistureSoilTest.DateTest = moistureSoilTest.DateTest;
            dbMoistureSoilTest.DocumentTest = moistureSoilTest.DocumentTest;
            dbMoistureSoilTest.SoilDryMassWithBox = moistureSoilTest.SoilDryMassWithBox;
            dbMoistureSoilTest.SoilWetMassWithBox = moistureSoilTest.SoilWetMassWithBox;
            dbMoistureSoilTest.BoxMass = moistureSoilTest.BoxMass;
            dbMoistureSoilTest.MoistureSoil = moistureSoilTest.MoistureSoil;

            _appDb.Entry(dbMoistureSoilTest.CustomerTest).State = EntityState.Modified;
            _appDb.Entry(dbMoistureSoilTest.SoilDryMassWithBox).State = EntityState.Modified;
            _appDb.Entry(dbMoistureSoilTest.SoilWetMassWithBox).State = EntityState.Modified;
            _appDb.Entry(dbMoistureSoilTest.BoxMass).State = EntityState.Modified;
            _appDb.Entry(dbMoistureSoilTest.MoistureSoil).State = EntityState.Modified;

            _appDb.SaveChanges();

            return true;
        }
    }
}
