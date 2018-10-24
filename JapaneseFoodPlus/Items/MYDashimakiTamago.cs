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
    public partial class MYDashimakiTamagoItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Dashimaki Tamago"; } }
        public override string FriendlyNamePlural 　　　　　　　　　　　　　　{ get { return "Dashimaki Tamago"; } } 
        public override string Description                      { get { return "A Japanese rolled omelet, blended with soup stock."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 7, Protein = 9, Vitamins = 1};
        public override float Calories                          { get { return 102; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MYCharcoalGrillSkill), 2)]    
    public partial class MYDashimakiTamagoRecipe : Recipe
    {
        public MYDashimakiTamagoRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYDashimakiTamagoItem>(),
                new CraftingElement<MYWoodenBowlItem>(typeof(MYCharcoalGrillEfficiencySkill), 15, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<GarbageItem>(typeof(MYCharcoalGrillEfficiencySkill), 1, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MYEggItem>(typeof(MYCharcoalGrillEfficiencySkill), 15, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<SugarItem>(typeof(MYCharcoalGrillEfficiencySkill), 10, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<OilItem>(typeof(MYCharcoalGrillEfficiencySkill), 5, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenPlateItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYDashimakiTamagoRecipe), Item.Get<MYDashimakiTamagoItem>().UILink(), 10, typeof(MYCharcoalGrillSpeedSkill)); 
            this.Initialize("Dashimaki Tamago", typeof(MYDashimakiTamagoRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}