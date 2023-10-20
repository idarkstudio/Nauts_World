using System.Collections.Generic;
using System.Text;
using UnityEngine.Scripting;


[System.Serializable]
[Preserve]
public class NftDelails
{
    [Preserve] public string name;
    [Preserve] public string image;
    [Preserve] public string description;
    [Preserve] public string collection;
    [Preserve] public bool isOwner;

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"nombre: {this.name}");
        sb.AppendLine($"descripcion: {this.description}");
        sb.AppendLine($"imagen: {this.image}");
        sb.AppendLine($"collection :{this.collection}");
        sb.AppendLine($"Es dueño :{this.isOwner}");
        return sb.ToString();
    }
}
