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
        public override string Description                      { get { return "Rice usually refers to the refined sake which assumes malted rice and water main raw materials. The liquor which was brewed by the manufacturing method peculiar to Japan."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 0, Protein = 1, Vitamins = 0};
        public override float Calories                          { get { return 520; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CulinaryArtsSkill), 4)]    
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
                new CraftingElement<RiceItem>(typeof(CulinaryArtsEfficiencySkill), 50, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<YeastItem>(typeof(CulinaryArtsEfficiencySkill), 30, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYRiceWineRecipe), Item.Get<MYRiceWineItem>().UILink(), 240, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Rice Wine", typeof(MYRiceWineRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}