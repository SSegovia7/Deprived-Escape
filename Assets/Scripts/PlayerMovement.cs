using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    enum Direction
    {
        LEFT = 0,
        RIGHT = 1,
        UP = 2,
        DOWN = 3
    }

    public float speed;
    public TextMeshProUGUI keyInfoText;

    private PlayerInput input;
    private InputAction moveAction;

    private Rigidbody2D rb;
    private SpriteRenderer rend;

    private Direction lastFacingDir;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();

        moveAction = input.actions["Move"];
    }

    char[] GetAllLetterChars()
    {
        char[] result = new char[26];

        int index = 0;
        for (char c = 'a'; c <= 'z'; c++)
        {
            result[index] = c;
            index++;
        }

        return result;
    }

    List<int> GetRandomNonrepeatingNumbers(int maxExc, int numWanted)
    {
        List<int> this_list = new();

        for (int i = 0; i < maxExc; i++) {
            this_list.Add(i);
        }

        this_list.Sort((int a, int b) => Random.Range(-1, 1));

        foreach (int elem in this_list)
            Debug.Log("elem" + elem.ToString());

        return this_list.GetRange(0, numWanted);

    }

    string RandomlyChangeWASD()
    {
        char[] letterChars = GetAllLetterChars();

        List<int> randomKeyIndices = GetRandomNonrepeatingNumbers(letterChars.Length, 4);

        string curInfoText = "";

        string[] dirs = { "LEFT", "RIGHT", "UP", "DOWN" };

        for (int i = 0; i < randomKeyIndices.Count; i++)
        {
            char inpChar = letterChars[randomKeyIndices[i]];
            string bindStr = "<Keyboard>/" + inpChar.ToString();
            moveAction.ApplyBindingOverride(i + 1, bindStr);

            curInfoText += $"{inpChar} = {dirs[i]}\n";
        }

        return curInfoText;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastFacingDir = Direction.UP;

        string infoText = RandomlyChangeWASD();
        keyInfoText.text = infoText;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetFacing(Direction dir)
    {
        int newAngle = 0;
        switch (dir)
        {
            case Direction.LEFT:
                newAngle = 90;
                break;
            case Direction.RIGHT:
                newAngle = 270;
                break;
            case Direction.UP:
                newAngle = 0;
                break;
            case Direction.DOWN:
                newAngle = 180;
                break;

        }
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, newAngle);
    }

    private Direction GetMostExtremeDirection(Vector2 movementVec)
    {
        float leftExt = -movementVec.x;
        float rightExt = movementVec.x;
        float upExt = movementVec.y;
        float downExt = -movementVec.y;

        float[] dirs = { leftExt, rightExt, upExt, downExt };

        int largestDirIndex = (int)lastFacingDir;

        for (int i = 0; i < dirs.Length; i++)
        {
            if (dirs[i] > dirs[largestDirIndex])
            {
                largestDirIndex = i;
                break;
            }
        }

        return (Direction)largestDirIndex;
    }

    private void FixedUpdate()
    {
        //Debug.Log(moveAction.ReadValue<Vector2>());
        Vector2 inputVec = moveAction.ReadValue<Vector2>();
        Vector2 movement = speed * Time.fixedDeltaTime * inputVec;
        //Debug.Log(movement);
        rb.AddForce(movement, ForceMode2D.Impulse);

        Direction dirToFace = GetMostExtremeDirection(movement);
        SetFacing(dirToFace);
        lastFacingDir = dirToFace;
    }
}
