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
        public override string FriendlyNamePlural 　　　　　　　　　　　　　　{ get { return "Katsuo No Tataki"; } } 
        public override string Description                      { get { return "A dish using bonitos, only the surface of the bonitos are heaten. it is eaten with spice and sauce."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 1, Protein = 26, Vitamins = 2};
        public override float Calories                          { get { return 115; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYCuttingBoardObject))]          
    [RequiresSkill(typeof(MYHighestNigiriSkill), 2)]    
    public partial class MYKatsuoNoTatakiRecipe : Recipe
    {
        public MYKatsuoNoTatakiRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYKatsuoNoTatakiItem>(3),
                new CraftingElement<GarbageItem>(typeof(MYHighestNigiriEfficiencySkill), 1, MYHighestNigiriEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawFishItem>(1), 
                new CraftingElement<MYSoySauceItem>(typeof(MYHighestNigiriEfficiencySkill), 5, MYHighestNigiriEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenPlateItem>(3), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYKatsuoNoTatakiRecipe), Item.Get<MYKatsuoNoTatakiItem>().UILink(), 5, typeof(MYHighestNigiriSpeedSkill)); 
            this.Initialize("Katsuo No Tataki", typeof(MYKatsuoNoTatakiRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}