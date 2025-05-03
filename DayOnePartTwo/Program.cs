var text = "";
using (var file = new StreamReader("./input.txt"))
{
    text = file.ReadToEnd();
}

var leftList = new List<int>();
var rightList = new List<int>();

var lines = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

foreach (var line in lines)
{
    var parts = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

    if (parts.Length == 2 &&
        int.TryParse(parts[0], out int left) &&
        int.TryParse(parts[1], out int right))
    {
        leftList.Add(left);
        rightList.Add(right);
    }
}

leftList.Sort();
rightList.Sort();

var similarity = 0;
for (int i = 0; i < leftList.Count; i++)
{
    var numberInRight = 0;
    Console.WriteLine($"Left number {leftList[i]}");
    for (int j = 0; j < rightList.Count; j++)
    {

        Console.WriteLine($"right number {rightList[j]}");
        if (leftList[i] == rightList[j])
        {

            numberInRight++;
        }
    }
    Console.WriteLine($"number in right: {numberInRight}");
    similarity += numberInRight * leftList[i];
}

Console.WriteLine($"result: {similarity}");
