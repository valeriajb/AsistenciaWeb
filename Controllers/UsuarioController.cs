using AsistenciaHuellaWeb.Data;
using AsistenciaHuellaWeb.Models;
using Microsoft.AspNetCore.Mvc;
namespace AsistenciaHuellaWeb.Controllers
{
    public class UsuarioController : Controller
    {
        ClsUsuarioData DataUser = new ClsUsuarioData();
        public IActionResult LeerDatos()
        {
            var listUser = DataUser.LeerDatos();
            return View(listUser);
        }

        //Solo devuelve la vista
        public IActionResult AgregarUsuario()
        {

            return View();
        }

        //Hace la opciòn de agregar
        [HttpPost]
        public IActionResult AgregarUsuario(ClsUsuarioModel usuario)
        {
            var respuesta = DataUser.AgregarUsuario(usuario);

            if (respuesta)
               return RedirectToAction("LeerDatos");
            else
                return View();

        }



        public IActionResult EditarUsuario(int Id_Usuario)
        {
            var dataUser =DataUser.ObtenerUsuario(Id_Usuario);
            return View(dataUser);
        }
        [HttpPost]
        public IActionResult EditarUsuario(ClsUsuarioModel usuario)
        {
            var respuesta = DataUser.EditarUsuario(usuario);

            if (respuesta)
                return RedirectToAction("LeerDatos");
            else
                return View();
        }
    }
}
