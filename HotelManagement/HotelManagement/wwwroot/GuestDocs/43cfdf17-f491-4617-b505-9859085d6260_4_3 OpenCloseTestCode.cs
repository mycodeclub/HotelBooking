
public class Shape
{
    private string _type { get; set; } 
    public int l;
    public int b;

    public Shape(string type)
    {`
        _type = type;
    }
    public float GetArea()
    {
        float area = 0f;
        switch (_type)
        {
            case "square":
                area = l * 2;
                break;
            case "rightangle":
                area = l * b;
                break; 
        }
        return area;
    } 
}