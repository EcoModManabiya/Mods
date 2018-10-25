namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    
    [Serialized]
    [Weight(100)]                                          
    public partial class MYRiceWineItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Rice Wine"; } }
        public override string FriendlyNamePlural 　　　　　　　　　　　　　　{ get { return "Rice Wine"; } } 
        public override string Description                      { get { return "A Japanese traditional rice wine called sake is made with rice malt that they cald kouji and water."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 7, Fat = 0, Protein = 1, Vitamins = 0};
        public override float Calories                          { get { return 185; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MYBestSmellSkill), 4)]    
    public partial class MYRiceWineRecipe : Recipe
    {
        public MYRiceWineRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYRiceWineItem>(2),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RiceItem>(typeof(MYBestSmellEfficiencySkill), 50, MYBestSmellEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<YeastItem>(typeof(CulinaryArtsEfficiencySkill), 30, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYMeasureItem>(2), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYRiceWineRecipe), Item.Get<MYRiceWineItem>().UILink(), 120, typeof(MYBestSmellSpeedSkill)); 
            this.Initialize("Rice Wine", typeof(MYRiceWineRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}