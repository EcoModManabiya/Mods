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
        public override string Description                      { get { return "A bowl of rice topped with Eel that it is broiled by soy sauce. The bowl is a traditional bowl called juubako."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 104, Fat = 23, Protein = 31, Vitamins = 7};
        public override float Calories                          { get { return 772; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYFlyingPanObject))]          
    [RequiresSkill(typeof(MYCharcoalGrillSkill), 4)]    
    public partial class MYUnajuRecipe : Recipe
    {
        public MYUnajuRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYUnajuItem>(),
                new CraftingElement<GarbageItem>(typeof(MYCharcoalGrillEfficiencySkill), 2, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RiceItem>(typeof(MYRiceCookingEfficiencySkill), 100, MYRiceCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<RawFishItem>(typeof(MYCharcoalGrillEfficiencySkill), 10, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYSoySauceItem>(typeof(MYCharcoalGrillEfficiencySkill), 10, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<SugarItem>(typeof(MYCharcoalGrillEfficiencySkill), 10, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenBowlItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYUnajuRecipe), Item.Get<MYUnajuItem>().UILink(), 15, typeof(MYCharcoalGrillSpeedSkill)); 
            this.Initialize("Unaju", typeof(MYUnajuRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}