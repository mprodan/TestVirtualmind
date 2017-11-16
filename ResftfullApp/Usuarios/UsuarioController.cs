using System;
using Nancy;
using Nancy.ModelBinding;
using System.Linq;

namespace ResftfullApp
{
    public class UsuarioController : NancyModule
    {
        DBManager _db = new DBManager();

        public UsuarioController()
        {
            Get["MyResftfullApp/usuarios"] = GetUsers;
            Get["MyResftfullApp/usuarios/{id}"] = GetUser;
            Delete["MyResftfullApp/usuarios"] = DeleteUser;
            Put["MyResftfullApp/usuarios"] = UpdateUser;
            Post["MyResftfullApp/usuarios"] = CreateUser;
        }

        private dynamic UpdateUser(dynamic parameters)
        {
            var u = this.Bind<Usuarios>();
            u = _db.UpdateUser(u);
            return Response.AsJson(u);
        }

        private dynamic CreateUser(dynamic parameters)
        {
            var u = this.Bind<Usuarios>();
            u = _db.CreateUser(u);
            return Response.AsJson(u);
        }

        private dynamic GetUser(dynamic parameters)
        {
            var u = _db.GetAll().Where(p=> p.ID== parameters.id);
            return Response.AsJson(u);
        }

        private dynamic GetUsers(dynamic parameters)
        {
            var u = _db.GetAll();
            return Response.AsJson(u);
        }

        private dynamic DeleteUser(dynamic parameters)
        {
            var u = this.Bind<Usuarios>();
            _db.DeleteUser(u);
            return HttpStatusCode.OK;
        }

    }
}
