using ilearn_users_api.Controllers.Requests;
using ilearn_users_api.Controllers.Responses;
using ilearn_users_api.Data.Repositories;
using ilearn_users_api.Domain.Entities;
using ilearn_users_api.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace ilearn_users_api.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("cadastro")]
        public ActionResult AddUser([FromBody] AddUserRequest request)
        {
            var user = new User(request.Name, request.Email, request.Phone, request.Password);
            var address = new Address(request.Street, request.Number, request.City, request.State, request.Country, request.ZipCode);
            user.AttributeAddress(address);

            if (!user.Validate())
            {
                return BadRequest(
                    new
                    {
                        errors = user.ValidationResult.Errors.Select(_ => _.ErrorMessage),
                    });
            }

            _userRepository.Insert(user);

            return Ok(
                new
                {
                    data = "Conta criada com sucesso!"
                }
            );
        }
       
        
        /* FUNCIONA */
         
        [HttpGet("user/all")]
        public async Task<IActionResult> Search()
        {
            var users = await _userRepository.SearchAsync();

            var list = users.Select(_ => new UserList
            {
                Id = _.Id,
                Name = _.Name,
                Email = _.Email,
                Phone = _.Phone,
                Address = new AddressDto
                {
                    Street = _.Address.Street,
                    Number = _.Address.Number,
                    City = _.Address.City,
                    State = _.Address.State,
                    Country = _.Address.Country,
                    ZipCode = _.Address.ZipCode,
                }
            });

            return Ok(list);
            
        }
    

        /*
         * Ideal
        [HttpGet("user/all")]
        [SwaggerOperation(
          Summary = "Search Users",
          Description = "Search Users with Pagination"
        )]
        [SwaggerResponse(200, "Assets List", typeof(UsersResponse))]
        //[SwaggerBadRequestResponse]
        //[SwaggerInternalErrorResponse]
        //[SwaggerRequestExample(typeof(AssetsRequest), typeof(AssetsRequestExample))]
        public async Task<IActionResult> Search([FromBody] UsersRequest searchUserQuery, [FromQuery] Pagination pagination, CancellationToken cancellationToken)
        {

            var result = await _userService.SearchAsync(searchUserQuery, pagination, cancellationToken);
            return Ok(result);


        }*/

        [HttpGet("user/{id}")]
        public ActionResult GetUser(string id)
        {
            var user = _userRepository.GetById(id);

            if (user == null)
                return NotFound();

            var show = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Address = new AddressDto
                {
                    Street = user.Address.Street,
                    Number = user.Address.Number,
                    City = user.Address.City,
                    State = user.Address.State,
                    Country = user.Address.Country,
                    ZipCode = user.Address.ZipCode,
                }
            };

            return Ok(
                new
                {
                    data = show
                }
            );
        }

        [HttpPut("user")]
        public ActionResult UpdateUser([FromBody] UserFullUpdate userFullUpdate)
        {
            var user = _userRepository.GetById(userFullUpdate.Id);

            if (user == null)
                return NotFound();

            user = new User(userFullUpdate.Id, userFullUpdate.Name, userFullUpdate.Email, userFullUpdate.Phone, userFullUpdate.Password);
            var address = new Address(
                userFullUpdate.Street,
                userFullUpdate.Number,
                userFullUpdate.City,
                userFullUpdate.State,
                userFullUpdate.Country,
                userFullUpdate.ZipCode);

            user.AttributeAddress(address);

            if (!user.Validate())
            {
                return BadRequest(
                    new
                    {
                        errors = user.ValidationResult.Errors.Select(_ => _.ErrorMessage)
                    });
            }

            if (!_userRepository.FullUpdate(user))
            {
                return BadRequest(new
                {
                    errors = "Nenhum documento foi alterado"
                });
            }

            return Ok(
                new
                {
                    data = "Usuário alterado com sucesso"
                }
            );
        }

        [HttpPatch("user/{id}")]
        public ActionResult UpdateAddress(string id, [FromBody] UserPartialUpdate userPartialUpdate)
        {
            var user = _userRepository.GetById(id);
            var address = new Address(userPartialUpdate.Street, userPartialUpdate.Number, userPartialUpdate.City, userPartialUpdate.State, userPartialUpdate.Country, userPartialUpdate.ZipCode);

            if (user == null)
                return NotFound();

            if (!_userRepository.PartialUpdate(id, address))
            {
                return BadRequest(new
                {
                    errors = "Nenhum documento foi alterado"
                });
            }

            return Ok(
                new
                {
                    data = "Endereço alterado com sucesso"
                }
            );
        }

        //[HttpGet("user")]
        //public ActionResult GetAvailableTeachers([FromQuery] string courseName)
        //{
        //    var availableTeachers = _userRepository.SearchTeacherByCourseName(courseName);

        //    var teachers = availableTeachers.Select(_ => new UserList
        //    {
        //        Id = _.Id,
        //        Name = _.Name,
        //        City = _.Address.City,
        //    });

        //    return Ok(
        //        new
        //        {
        //            data = teachers
        //        }
        //    );
        //}

        //[HttpPatch("restaurante/{id}/avaliar")]
        //public ActionResult AvaliarRestaurante(string id, [FromBody] AvaliacaoInclusao avaliacaoInclusao)
        //{
        //    var restaurante = _restauranteRepository.ObterPorId(id);

        //    if (restaurante == null)
        //        return NotFound();

        //    var avaliacao = new Avaliacao(avaliacaoInclusao.Estrelas, avaliacaoInclusao.Comentario);

        //    if (!avaliacao.Validar())
        //    {
        //        return BadRequest(
        //            new
        //            {
        //                errors = avaliacao.ValidationResult.Errors.Select(_ => _.ErrorMessage)
        //            });
        //    }

        //    _restauranteRepository.Avaliar(id, avaliacao);

        //    return Ok(
        //        new
        //        {
        //            data = "Restaurante avaliado com sucesso"
        //        }
        //    );
        //}

        //[HttpGet("restaurante/top3")]
        //public async Task<ActionResult> ObterTop3Restaurantes()
        //{
        //    var top3 = await _restauranteRepository.ObterTop3();

        //    var listagem = top3.Select(_ => new RestauranteTop3
        //    {
        //        Id = _.Key.Id,
        //        Nome = _.Key.Nome,
        //        Cozinha = (int)_.Key.Cozinha,
        //        Cidade = _.Key.Endereco.Cidade,
        //        Estrelas = _.Value
        //    });

        //    return Ok(
        //        new
        //        {
        //            data = listagem
        //        }
        //    );
        //}

        //[HttpGet("restaurante/top3-lookup")]
        //public async Task<ActionResult> ObterTop3RestaurantesComLookup()
        //{
        //    var top3 = await _restauranteRepository.ObterTop3_ComLookup();

        //    var listagem = top3.Select(_ => new RestauranteTop3
        //    {
        //        Id = _.Key.Id,
        //        Nome = _.Key.Nome,
        //        Cozinha = (int)_.Key.Cozinha,
        //        Cidade = _.Key.Endereco.Cidade,
        //        Estrelas = _.Value
        //    });

        //    return Ok(
        //        new
        //        {
        //            data = listagem
        //        }
        //    );
        //}

        //[HttpDelete("restaurante/{id}")]
        //public ActionResult Remover(string id)
        //{
        //    var restaurante = _restauranteRepository.ObterPorId(id);

        //    if (restaurante == null)
        //        return NotFound();

        //    (var totalRestauranteRemovido, var totalAvaliacoesRemovidas) = _restauranteRepository.Remover(id);

        //    return Ok(
        //        new
        //        {
        //            data = $"Total de exclusões: {totalRestauranteRemovido} restaurante com {totalAvaliacoesRemovidas} avaliações"
        //        }
        //    );
        //}

        //[HttpGet("restaurante/textual")]
        //public async Task<ActionResult> ObterRestaurantePorBuscaTextual([FromQuery] string texto)
        //{
        //    var restaurantes = await _restauranteRepository.ObterPorBuscaTextual(texto);

        //    var listagem = restaurantes.ToList().Select(_ => new RestauranteListagem
        //    {
        //        Id = _.Id,
        //        Nome = _.Nome,
        //        Cozinha = (int)_.Cozinha,
        //        Cidade = _.Endereco.Cidade
        //    });

        //    return Ok(
        //        new
        //        {
        //            data = listagem
        //        }
        //    );
        //}
    }
}