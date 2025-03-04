
using Microsoft.AspNetCore.Mvc;
using API.Controllers.API.Controllers;
using AutoMapper;
using API.Models.Entity;
using API.Repository.IRepository;
using API.Models.DTOs.PujaDTO;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PujaController : BaseController<PujaEntity, PujaDTO, CreatePujaDTO>
    {

        public PujaController(IPujaRepository pujaRepository,
            IMapper mapper, ILogger<IPujaRepository> logger)
            : base(pujaRepository, mapper, logger)
        {

        }
    }
}