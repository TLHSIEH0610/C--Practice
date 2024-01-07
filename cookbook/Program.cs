var recipeApp = new RecipeApp(new RecipeRepository(), new RecipeUserInteraction());
recipeApp.Run();

public class RecipeApp
{

    private readonly RecipeRepository _recipeRepository;
    private readonly RecipeUserInteraction _recipeUserInteraction;

    public RecipeApp(RecipeRepository recipeRepository, RecipeUserInteraction recipeUserInteraction)
    {

        _recipeRepository = recipeRepository;
        _recipeUserInteraction = recipeUserInteraction;
    }

    public void Run()
    {
        var allRecipes = _recipeRepository.Read(filepath);
        _recipeUserInteraction.PrintExistingRecipes(allRecipes);
        _recipeUserInteraction.PromptToCreateRecipe();
        var ingredients = _recipeUserInteraction.ReadIngredientsFromUser();

        if (ingredients.Count > 0)
        {
            var recipe = new Recipe(ingredients);
            allRecipes.Add(recipe);
            _recipeRepository.write(filePath, allRecipes);
            _recipeUserInteraction.showMessage("recipe added");
            _recipeUserInteraction.showMessage(recipe.ToString());


        }
        else
        {
            _recipeUserInteraction.ShowMessage("No ingredients have been selected.");
        }

        _recipeUserInteraction.Exit();

    }
}

public class RecipeRepository
{

}

public class RecipeUserInteraction
{

}

public class Recipe { }