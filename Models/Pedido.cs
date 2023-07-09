using System;
using System.Collections.Generic;

namespace CRUD_EF.Models;

public partial class Pedido
{
    public int PedidoId { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaPedido { get; set; }

    public int ClienteId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;
}
