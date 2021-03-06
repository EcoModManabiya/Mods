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
    public partial class MYDengakuItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Dengaku"; } }
        public override string FriendlyNamePlural 　　　　　　　　　　　　　　{ get { return "Dengaku"; } } 
        public override string Description                      { get { return "Dengaku is a dish made by konjac japanese radish cald daikon etc they boiled it and spit it in a bamboo skewer and eat with miso paste."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 9, Fat = 5, Protein = 9, Vitamins = 0};
        public override float Calories                          { get { return 131; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYFlyingPanObject))]          
    [RequiresSkill(typeof(MYCharcoalGrillSkill), 2)]    
    public partial class MYDengakuRecipe : Recipe
    {
        public MYDengakuRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYDengakuItem>(),
                new CraftingElement<MYWoodenPlateItem>(typeof(MYCharcoalGrillEfficiencySkill), 10, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MYTofuItem>(typeof(MYCharcoalGrillEfficiencySkill), 10, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<SugarItem>(typeof(MYCharcoalGrillEfficiencySkill), 5, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYMisoItem>(typeof(MYCharcoalGrillEfficiencySkill), 5, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenPlateItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYDengakuRecipe), Item.Get<MYDengakuItem>().UILink(), 5, typeof(MYCharcoalGrillSpeedSkill)); 
            this.Initialize("Dengaku", typeof(MYDengakuRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}