
# Unity Base Stack Controller
If you are in the hyper-casual game industry, you know you are gonna make a lot of stacking games. After making (!)thousands of stacking games, I decided to create a base stack controller class to increase my efficiency. [Read More...](https://www.github.com/octokatherine)



## Technologies

**Unity, C#, Unity Generic Pool**
  ## Interface

```csharp
public interface IStackController
{
    public GameObject AddStack();
    public void RemoveStack();
    public void RemoveStackWithId(int id);
    public StackUnit GetLastActive();
}

```

## Example Usage

```csharp
public class TestController: StackControllerBase_AFRF
{
    [SerializeField] private int id;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddStack();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            RemoveStack();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RemoveStackWithId(id);
        }
    }
}
```
  
