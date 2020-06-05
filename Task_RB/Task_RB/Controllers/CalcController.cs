using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceReference1;
using Task_RB.DAL;
using Task_RB.Helpers;
using Task_RB.Models;

namespace Task_RB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        private readonly CalcDbContext _db;
        private readonly CalculatorSoapClient _calculatorSoap;
        private readonly ILogger<CalcController> _logger;
        public CalcController(CalcDbContext calcDbContext, ILogger<CalcController> logger)
        {
            _calculatorSoap = new CalculatorSoapClient(CalculatorSoapClient.EndpointConfiguration.CalculatorSoap12);        
            _db = calcDbContext;
            _logger = logger;
        }

        [HttpGet]//[HttpPost("add")]
        [Route("add")]
        public async Task<ActionResult> AddAsync([FromQuery] Number number)
        {
            try
            {
                bool flag = _db.CalcFunctions.Any(r => r.Id == 1);
                if (!flag)
                {
                    _logger.LogError($"Warning Warning Warning CalcFunction Don't Exist");
                    throw new ArgumentException("Please Get Connecting with Owner");
                }

                int result = await _calculatorSoap.AddAsync(number.Number_1, number.Number_2);
                string message = Message.Info(number, (int)CalcOperation.Operation.Add, result);

                await _db.WriteDbContext(1, message);
                _logger.LogInformation(message);

                return Content($"Adding {number.Number_1} + {number.Number_2} = {result}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Warning Warning Warning in Adding Method ! {ex}");
                throw new ArgumentException("Please Get Connecting with Owner");
            }
        }


        [HttpGet]
        [Route("subtract")]
        public async Task<ActionResult> Subtract([FromQuery] Number number)
        {
            try
            {
                bool flag = _db.CalcFunctions.Any(r => r.Id == 2);
                if (!flag)
                {
                    _logger.LogError($"Warning Warning Warning CalcFunction Don't Exist");
                    throw new ArgumentException("Please Get Connecting with Owner");
                }

                int result = await _calculatorSoap.SubtractAsync(number.Number_1, number.Number_2);
                string message = Message.Info(number, (int)CalcOperation.Operation.Subtract, result);

                await _db.WriteDbContext(2, message);
                _logger.LogInformation(message);

                return Content($"Subtract {number.Number_1} - {number.Number_2} = {result}");

            }
            catch (Exception ex)
            {
                _logger.LogError($"Warning Warning Warning in Adding Method ! {ex}");
                throw new ArgumentException("Please Get Connecting with Owner"); ;
            }
        }

        [HttpGet]
        [Route("multiply")]
        public async Task<ActionResult> Multiply([FromQuery] Number number)
        {
            try
            {
                bool flag = _db.CalcFunctions.Any(r => r.Id == 3);
                if (!flag)
                {
                    _logger.LogError($"Warning Warning Warning CalcFunction Don't Exist");
                    throw new ArgumentException("Please Get Connecting with Owner");
                }

                int result = await _calculatorSoap.MultiplyAsync(number.Number_1, number.Number_2);
                string message = Message.Info(number, (int)CalcOperation.Operation.Multiply, result);

                await _db.WriteDbContext(3, message);
                _logger.LogInformation(message);

                return Content($"Multiply {number.Number_1} * {number.Number_2} = {result}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Warning Warning Warning in Adding Method ! {ex}");
                throw new ArgumentException("Please Get Connecting with Owner"); ;
            }
        }

        [HttpGet]
        [Route("divide")]
        public async Task<ActionResult> Divide([FromQuery] Number number)
        {
            try
            {
                bool flag = _db.CalcFunctions.Any(r => r.Id == 4);
                if (!flag)
                {
                    _logger.LogError($"Warning Warning Warning CalcFunction Don't Exist");
                    throw new ArgumentException("Please Get Connecting with Owner");
                }

                int result = await _calculatorSoap.DivideAsync(number.Number_1, number.Number_2);
                string message = Message.Info(number, (int)CalcOperation.Operation.Divide, result);

                await _db.WriteDbContext(4, message);
                _logger.LogInformation(message);

                return Content($"Divide {number.Number_1} / {number.Number_2} = {result}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Warning Warning Warning in Adding Method ! {ex}");
                throw new ArgumentException("Please Get Connecting with Owner"); ;
            }
        }
    }

}