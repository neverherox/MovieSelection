﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using MovieSelection.Data.Context;
using MovieSelection_Api.MLModel;

namespace MovieSelection.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationsController : ControllerBase
    {
        private readonly MovieSelectionContext _context;

        public RecommendationsController(MovieSelectionContext context)
        {
            _context = context;
        }

        [HttpPost("retrain")]
        public ActionResult RetrainModel()
        {
            var mlContext = new MLContext();
            var rates = _context.Rates.ToList();
            var rateInputs = new List<RateMLModel.ModelInput>();
            foreach(var rate in rates)
            {
                rateInputs.Add(new RateMLModel.ModelInput
                {
                    MovieId = rate.MovieId,
                    UserId = rate.UserId.ToString(),
                    Value = rate.Value
                });
            }
            var data = mlContext.Data.LoadFromEnumerable(rateInputs);
            var retrainedModel = RateMLModel.RetrainPipeline(mlContext, data);
            mlContext.Model.Save(retrainedModel, data.Schema, "MLModels/RateMLModel.zip");
            return Ok();
        }
    }
}
