using System;
using System.Collections.Generic;

namespace testactualisation.Appdata
{
    public partial class RolesPrivilege
    {
        public int Idrole { get; set; }
        public int Idprivilege { get; set; }

        public Privileges IdprivilegeNavigation { get; set; }
        public Roles IdroleNavigation { get; set; }
    }
}
