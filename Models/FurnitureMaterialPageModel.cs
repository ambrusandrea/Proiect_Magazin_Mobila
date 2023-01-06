using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Magazin_Mobila.Data;

namespace Proiect_Magazin_Mobila.Models
{
    public class FurnitureMaterialPageModel : PageModel
    {
        public List<AssignedMaterialData> AssignedMaterialDataList;
        public void PopulateAssignedMaterialData(Proiect_Magazin_MobilaContext context,
        Furniture furniture)
        {
            var allMaterials = context.Material;
            var furnitureMaterials = new HashSet<int>(
            furniture.FurnitureMaterials.Select(c => c.MaterialID)); //
            AssignedMaterialDataList = new List<AssignedMaterialData>();
            foreach (var cat in allMaterials)
            {
                AssignedMaterialDataList.Add(new AssignedMaterialData
                {
                    MaterialID = cat.ID,
                    Name = cat.MaterialName,
                    Assigned = furnitureMaterials.Contains(cat.ID)
                });
            }
        }
        public void UpdateFurnitureMaterials(Proiect_Magazin_MobilaContext context,
        string[] selectedMaterials, Furniture furnitureToUpdate)
        {
            if (selectedMaterials == null)
            {
                furnitureToUpdate.FurnitureMaterials = new List<FurnitureMaterial>();
                return;
            }
            var selectedMaterialsHS = new HashSet<string>(selectedMaterials);
            var furnitureMaterials = new HashSet<int>
            (furnitureToUpdate.FurnitureMaterials.Select(c => c.Material.ID));
            foreach (var cat in context.Material)
            {
                if (selectedMaterialsHS.Contains(cat.ID.ToString()))
                {
                    if (!furnitureMaterials.Contains(cat.ID))
                    {
                        furnitureToUpdate.FurnitureMaterials.Add(
                        new FurnitureMaterial
                        {
                            FurnitureID = furnitureToUpdate.ID,
                            MaterialID = cat.ID
                        });
                    }
                }
                else
                {
                    if (furnitureMaterials.Contains(cat.ID))
                    {
                        FurnitureMaterial courseToRemove
                        = furnitureToUpdate
                        .FurnitureMaterials
                        .SingleOrDefault(i => i.MaterialID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

    }
}
