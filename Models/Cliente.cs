using System;
using System.Collections.Generic;

namespace CRUD_EF.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
