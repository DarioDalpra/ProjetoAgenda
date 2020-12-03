using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda_WEB.DAL;
using Agenda_WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Agenda_WEB.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Context _context;
        private readonly UsuarioDAO _usuarioDAO;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public UsuarioController(Context context, UserManager<Usuario> userManager,
                                 SignInManager<Usuario> signInManager, UsuarioDAO usuarioDAO)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _usuarioDAO = usuarioDAO;
        }

        // GET: Usuario
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioView = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioView == null)
            {
                return NotFound();
            }

            return View(usuarioView);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Rg,Nascimento,Telefone,Email,Senha,ConfirmacaoSenha,Cep,Logradouro,Numero,Bairro,Localidade,Uf")] UsuarioView usuarioView)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario
                {
                    //UserName = usuarioView.Email,
                    //Email = usuarioView.Email,
                    //Cep = usuarioView.Cep,
                    //Logradouro = usuarioView.Logradouro,
                    //Bairro = usuarioView.Bairro,
                    //Localidade = usuarioView.Localidade,
                    //Uf = usuarioView.Uf
                    Nome = usuarioView.Nome,
                    UserName = usuarioView.Email,
                    Email = usuarioView.Email,
                    Cpf = usuarioView.Cpf,
                    Rg = usuarioView.Rg,
                    Nascimento = usuarioView.Nascimento,
                    Telefone = usuarioView.Telefone,
                    Cep = usuarioView.Cep,
                    Logradouro = usuarioView.Logradouro,
                    Numero = usuarioView.Numero,
                    Bairro = usuarioView.Bairro,
                    Localidade = usuarioView.Localidade,
                    Uf = usuarioView.Uf
                };

                IdentityResult resultado = await _userManager.CreateAsync(usuario, usuarioView.Senha);
                if (resultado.Succeeded)
                {
                    _context.Add(usuarioView);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                AdicionarErros(resultado);
            }
            return View(usuarioView);
        }

        public void AdicionarErros(IdentityResult resultado)
        {
            foreach (IdentityError erro in resultado.Errors)
            {
                ModelState.AddModelError("", erro.Description);
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email, Senha")] UsuarioView usuarioview)
        {
            var result = await _signInManager.PasswordSignInAsync(usuarioview.Email, usuarioview.Senha, false, false);
            string name = _signInManager.Context.User.Identity.Name;
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Login ou Senha inválido!");
            return View(usuarioview);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Usuarios = new SelectList(_usuarioDAO.Listar(), "Id,Nome,Cpf,Rg,Nascimento,Telefone,Email,Senha,ConfirmacaoSenha,Cep,Logradouro,Numero,Bairro,Localidade,Uf");
            return View(_usuarioDAO.BuscarPorId(id));
        }
        [HttpPost]
        public IActionResult Edit(UsuarioView usuarioview)
        {
            _usuarioDAO.Editar(usuarioview);
            return RedirectToAction("Index", "Usuario");
        }
    }
}