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
    public partial class MYDashimakiTamagoItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Dashimaki Tamago"; } }
        public override string Description                      { get { return "I mix soup stock with a beaten egg and am a fried dish to harden."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 1, Fat = 10, Protein = 13, Vitamins = 1};
        public override float Calories                          { get { return 420; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CulinaryArtsSkill), 4)]    
    public partial class MYDashimakiTamagoRecipe : Recipe
    {
        public MYDashimakiTamagoRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYDashimakiTamagoItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MYEggItem>(typeof(CulinaryArtsEfficiencySkill), 15, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<SugarItem>(typeof(CulinaryArtsEfficiencySkill), 10, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<OilItem>(typeof(CulinaryArtsEfficiencySkill), 5, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYDashimakiTamagoRecipe), Item.Get<MYDashimakiTamagoItem>().UILink(), 20, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Dashimaki Tamago", typeof(MYDashimakiTamagoRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}