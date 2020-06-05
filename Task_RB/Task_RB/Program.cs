using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using Task_RB.DAL;

namespace Task_RB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var log = NLogBuilder.ConfigureNLog("Nlog.config").GetCurrentClassLogger();
            try
            {
                log.Debug("Start Application");
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Exception");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }


            var WebHostBuilder = CreateWebHostBuilder(args).Build();
            using (var scope = WebHostBuilder.Services.CreateScope())
            {
                using (var _db = scope.ServiceProvider.GetRequiredService<CalcDbContext>())
                {
                    var transaction = _db.Database.BeginTransaction();

                    try
                    {

                        for (int i = 1; i <= 4; i++)
                        {
                            if (!_db.CalcFunctions.Any(m => m.Id == i))
                            {
                                _db.CalcFunctions.Add(new Models.CalcFunction
                                {
                                    Id = i,
                                    Insert_Date = DateTimeOffset.UtcNow,
                                });
                            }
                        }

                        _db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                    finally
                    {
                        transaction.Dispose();
                    }
                }
            }
            WebHostBuilder.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
          WebHost.CreateDefaultBuilder(args)
              .UseStartup<Startup>()
                 .ConfigureLogging(logging =>
                 {
                     logging.ClearProviders();
                     logging.SetMinimumLevel(LogLevel.Trace);
                 }).UseNLog();

    }

}
