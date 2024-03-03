﻿using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.TestTools.InfraSteructure.DataBaseConfig.Unit
{
    public class EFInMemoryDatabase : IDisposable
    {
        private readonly SqliteConnection _connection;

        public EFInMemoryDatabase()
        {
            _connection = new SqliteConnection("filename=:memory:");
            _connection.Open();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

        private ConstructorInfo? FindSuitableConstructor<TDbContext>()
            where TDbContext : DbContext
        {
            var flags = BindingFlags.Instance |
                        BindingFlags.Public |
                        BindingFlags.NonPublic |
                        BindingFlags.InvokeMethod;

            var constructor =
                typeof(TDbContext).GetConstructor(
                    flags,
                    null,
                    new[] { typeof(DbContextOptions<TDbContext>) },
                    null);

            if (constructor == null)
            {
                constructor = typeof(TDbContext).GetConstructor(
                    flags,
                    null,
                    new[]
                    {
                    typeof(DbContextOptions)
                    },
                    null);
            }

            if (constructor == null)
            {
                constructor = typeof(TDbContext).GetConstructor(
                    flags,
                    null,
                    new[]
                    {
                    typeof(DbContextOptions<TDbContext>),
                    },
                    null);
            }

            return constructor;
        }

        // private Func<TDbContext> ResolveFactory<TDbContext>()
        //     where TDbContext : DbContext
        // {
        //     var optionBuilder = new DbContextOptionsBuilder<TDbContext>();
        //     optionBuilder.EnableSensitiveDataLogging();
        //     var dbContextOptions = optionBuilder.UseSqlite(_connection).Options;
        //
        //     var constructor = FindSuitableConstructor<TDbContext>();
        //
        //     if (constructor == null)
        //     {
        //         throw new Exception(
        //             $"no constructor found on '{typeof(TDbContext).Name}' " +
        //             "with one parameter of type " +
        //             $"DbContextOptions<{typeof(TDbContext).Name}" +
        //             $">/DbContextOptions");
        //     }
        //
        //     return () =>
        //         (constructor.Invoke(
        //             new object[]
        //             {
        //                 dbContextOptions,
        //                 new Mock<IEventPublisher>().Object,
        //                 new Mock<UserTokenService>().Object,
        //                 new Mock<AuditLogService>().Object
        //             }) as
        //             TDbContext)!;
        // }

        private Func<TDbContext> ResolveFactory<TDbContext>()
            where TDbContext : DbContext
        {
            var optionBuilder = new DbContextOptionsBuilder<TDbContext>();
            optionBuilder.EnableSensitiveDataLogging();
            var dbContextOptions = optionBuilder.UseSqlite(_connection).Options;

            var constructor = FindSuitableConstructor<TDbContext>();

            if (constructor == null)
            {
                throw new Exception(
                    $"no constructor found on '{typeof(TDbContext).Name}' " +
                    "with one parameter of type " +
                    $"DbContextOptions<{typeof(TDbContext).Name}" +
                    $">/DbContextOptions");
            }

            return () =>
                (constructor.Invoke(
                        new object[]
                        {
                        dbContextOptions,
                        }) as
                    TDbContext)!;
        }

        public TDbContext CreateDataContext<TDbContext>()
            where TDbContext : DbContext
        {
            var dbContext = ResolveFactory<TDbContext>().Invoke();
            dbContext.Database.EnsureCreated();

            return dbContext;
        }
    }
}
