using Microsoft.AspNetCore.Mvc;
using SampleOrderService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleOrderService.Controllers
{
    public abstract class BaseController<T> : ControllerBase where T : IService
    {
        protected T Service { get; set; }

        protected BaseController(T service)
        {
            Service = service;
        }
    }
}
