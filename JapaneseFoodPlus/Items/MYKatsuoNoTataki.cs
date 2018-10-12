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
    [Weight(50)]                                          
    public partial class MYKatsuoNoTatakiItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Katsuo No Tataki"; } }
        public override string Description                      { get { return "Chopped bonito is fish dishes using the bonitos. I cut a bonito in the knob and after having warmed only the surface, I cool it and hang a limit, a spice and sauce and eat."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 2, Fat = 0, Protein = 10, Vitamins = 1};
        public override float Calories                          { get { return 120; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CulinaryArtsSkill), 1)]    
    public partial class MYKatsuoNoTatakiRecipe : Recipe
    {
        public MYKatsuoNoTatakiRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYKatsuoNoTatakiItem>(10),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawFishItem>(1), 
                new CraftingElement<MYSoySauceItem>(typeof(CulinaryArtsEfficiencySkill), 5, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYKatsuoNoTatakiRecipe), Item.Get<MYKatsuoNoTatakiItem>().UILink(), 10, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Katsuo No Tataki", typeof(MYKatsuoNoTatakiRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}