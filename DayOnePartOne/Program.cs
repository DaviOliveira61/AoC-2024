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

int totalDistance = 0;
for (int i = 0; i < leftList.Count; i++)
{
    totalDistance += Math.Abs(leftList[i] - rightList[i]);
}

Console.WriteLine(totalDistance);
