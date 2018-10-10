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
    [Weight(150)]                                          
    public partial class MYUnajuItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Unaju"; } }
        public override string Description                      { get { return "Eel and rice in a lacquered box is a Japanese bowl thing with the spitchcock on the white meal that I served it in a bowl."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 105, Fat = 19, Protein = 28, Vitamins = 2};
        public override float Calories                          { get { return 2000; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CulinaryArtsSkill), 4)]    
    public partial class MYUnajuRecipe : Recipe
    {
        public MYUnajuRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYUnajuItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RiceItem>(20), 
                new CraftingElement<RawFishItem>(typeof(CulinaryArtsEfficiencySkill), 10, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYSoySauceItem>(typeof(CulinaryArtsEfficiencySkill), 10, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<SugarItem>(typeof(CulinaryArtsEfficiencySkill), 10, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYUnajuRecipe), Item.Get<MYUnajuItem>().UILink(), 60, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Unaju", typeof(MYUnajuRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}