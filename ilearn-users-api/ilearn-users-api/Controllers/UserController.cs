using ilearn_users_api.Controllers.Requests;
using ilearn_users_api.Controllers.Responses;
using ilearn_users_api.Data.Repositories;
using ilearn_users_api.Domain.Entities;
using ilearn_users_api.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using MongoDB.Bson;
using AutoMapper;

namespace ilearn_users_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        //TODO: Criar usuário
        //TODO: Adicionar curso oferecido
        //TODO: Adicionar aula agendada

        //[HttpPost("cadastro")]
        //public ActionResult AddUser([FromBody] AddUserRequest request)
        //{
        //    var user = new User(request.Name, request.Email, request.Phone, request.Password);
        //    var address = new Address(request.Street, request.Number, request.City, request.State, request.Country, request.ZipCode);
        //    user.AttributeAddress(address);

        //    if (!user.Validate())
        //    {
        //        return BadRequest(
        //            new
        //            {
        //                errors = user.ValidationResult.Errors.Select(_ => _.ErrorMessage),
        //            });
        //    }

        //    _userRepository.Insert(user);

        //    return Ok(
        //        new
        //        {
        //            data = "Conta criada com sucesso!"
        //        }
        //    );
        //}

        //DONE: READ
        [HttpGet("{subject}")]
        public async Task<IActionResult> SearchBySubject(string subject)
        {
            var users = await _userRepository.SearchBySubjectAsync(subject);

            if (users == null)
                return NotFound("Nenhum professor encontrado");

            return Ok(_mapper.Map<List<UserDto>>(users));
        }

        [HttpGet("{subject}/{location}")]
        public async Task<IActionResult> SearchBySubject(string subject, string location)
        {
            var users = await _userRepository.SearchBySubjectAndLocationAsync(subject, location);

            if (users == null)
                return NotFound("Nenhum professor encontrado");

            return Ok(_mapper.Map<List<UserDto>>(users));
        }

        [HttpGet()]
        public async Task<IActionResult> SearchById(ObjectId id)
        {
            var user = await _userRepository.SearchByIdAsync(id);

            if (user == null)
                return NotFound("Professor não encontrado");

            return Ok(_mapper.Map<UserDto>(user));
        }
    }
}