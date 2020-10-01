# Player Movement From Scratch

## Overview

This repository will teach the basics of player movement in Unity

**CAUTION: It is your responsiblity to save your scene often to prevent losing your work.  It would also be a good idea to commit after every major step so that it will be easy to recover your work if you mess up somewhere along the way.**

## Getting Started

The Unity project has already been started so there is no need to start an new Unity project

1. Open Unity Hub
2. Navigate to the folder containing PlayerMovementFromScratch
3. Click Open

## Creating the Scene

Since we are starting with an empty scene we need to add something...

1. Create a folder called `Sprites`
2. Open the `Sprites` folder
3. Create a premade sprite
    1. Click the plus button under `Project` or right click in the empty space in the `Sprites`folder and select `Create`
    2. Select `Sprites`
    3. Select `Square`
4. Drag the `Square`into the Scene
    1. Rename `Square` to `Player`
5. Drag another `Square` into the the Scene
    1. Rename `Square` to `Ground`
6. With the Ground selected:
    1. Select the move tool (or press `W`)
    2. Move the ground to the bottom of the camera space
    3. Select the size tool (or press `R`)
    4. Resize the ground to extend a bit beyond the edge of the camera area (or change the x value in `Scale` to 30)
    5. In `Sprite Renderer` change the `Color` to Green (I'm using `R`: 18 `G`: 140 `B`: 40 `A`: 255 or `Hexadecimal`: 128C28)

## Making the Player a Player

If you were to press play now your scene would just be a scene that looks like a moon over a field. 
Your Player doesn't move or fall or anything. 
Now we could write a bunch of scripts to tell Unity to apply gravity to the Player but luckily for us Unity has some features built in to apply gravity for us.

### Apply Gravity to the Player

1. Select the `Player`
2. Click the `Add Component` button at the bottom of the inspector
    1. Select `Physics 2D`
    2. Select `Rigidbody 2D`

Looking at the Inspector for the player you will notice the `Rigidbody 2D` section.  In this section you see a bunch of properties that let the computer know that this sprite should have properties like gravity applied to it. If you press play you will see your Player fall through the ground. Thats because we applied phyics to the player but our ground sprite doesn't know how to interact with the Player. For that we can use a collider

### Apply a Collider to the Ground

1. Select the `Ground`
2. Click the `Add Component` button at the bottom of the inspector
    1. Select `Physics 2D`
    2. Select `Box Collider 2D`

You will notice this time that adding the box collider added its own set of properties to the Ground Sprite but if you press play the Player still goes through the Ground... What gives?

### Apply a Collider to the Player

The so that the Player and the Ground know about each other we should also add a collider to the Player.

1. Select the `Player`
2. Click the `Add Component` button at the bottom of the inspector
    1. Select `Physics 2D`
    2. Select `Box Collider 2D`

Now when you press play the Player should stop when it hits the ground.  Whats more is if you look closely at the Player or the Ground when they are selected you will see a thin green line around them to indicate that they have a collider on them. This green line can be expanded using the `Edit Collider` option within the `Box Collider 2D` section of the inspector.

## Applying Movement

So now our Player can fall to the Ground but we can't make it do anything.  Let's apply some movement to our Player! Don't be afraid, this next section requires a little bit of code. Lucky for us there are a lot of built in features of Unity that we can use to help us out.

1. Open the `Scripts` Folder
2. Right Click in the folder and go to `Create` then `C# Script`
3. Name the new script PlayerMovement
    1. Note: Always try to name your script immedately when you create it.  Unity requires that the script name matches the Class name in the script.  Unity will do this automatically if you name your file immediately but if you forget you will have to rename the class in the script to match the file name. This also applies if you choose to rename your file.
4. Drag the `PlayerMovement` file onto `Player`
    1. If you look in the inspector you can see the `Player Movement (Script)` has been added 
4. Double Click the `PlayerMovement` file
    1. This will open your IDE (Integrated Development Enviornment)
        1. Code files are usually just text files and could even be edited in Notepad or Text Edit on a Mac
        2. The IDE helps to make writing code a whole lot easier than in a plain Notepad by using features like code completion and syntax highlighting. 
        3. You will also notice that there is some code alread in here.  Every time Unity creates a C# script it creates it with a Start() method and an Update() method 
5. Lets add a public variable called moveSpeed just inside of the first curly brace and above the ```void Start()```. 

    1. Type: ```public float moveSpeed = 5f;``` ensuring to include the semicolon at the end
        1. **NOTE:** Float may seem strange but its the coding way of delcaring a number that we expect to have a decimal point 
        1. Save the file and open unity
        2. Notice that the `PlayerMovement` section now has a Move Speed property that is set to 5
            1. All public variables will show up in the inspector attached to the GameObject that the script is on.
6.  Under `moveSpeed` lets add two private variables for the Rigidbody2D.
    1. Type ```private Rigidbody2D rb;```
    3. **NOTE:** You may notice if you press save and look back in Unity that these variables don't appear in the Inspector.  This is because these variables are labeled as private.
7. Next we want to find the Rigidbody Component that we added to the Player earlier. To do this inside of the Start() curly braces we want to add:
    1. Type ```rb = GetComponent<Rigidbody2D>();```
        1. This line of code uses the `GetComponent` method to find the `Rigidbody2D` on the current `GameObject` which in this case is the Player and assigns it to the `rb` variable we created earlier.
            2. Remember the `Rigidbody2D` component applied gravity before, now we want to apply other forces to it so that it can move the player left and right instead of just down. 
8. **NOTE** There are a few different ways to implement movement this is only one but it will allow us to use Unity's built in controller movements or `Axes`.  You can access Axes by navigating to `Edit` -> `Project Settings` -> `Input Manager`.  In that section you will see `Axes` and if you press the arrown on the right it will expand to show you all of the `Axes` that Unity has built in.  For this part we want to focus on `Horizontal`
    1. Looking closely at `Horizontal` you can see that it has a field for Negative and Positive Button.  Left and Right map to the `left` and `right` buttons on the keyboard you can also see that it maps alternative buttons for Negative and Positive to `a` and `d`.
9. We need to add another variable to contain the Move direction data.  So back up at the top right under `facingRight` add moveDirection as a private float variable.
    1. Type: ```private float moveDirection;```
        1. We are using a float variable here because on an analog controller left and right are measured from -1 to 1 with 0 being in the middle. 
10. Inside the curly brackets of `Update()` we want to get user input and then apply that user input to the Players ridgidbody 
    1. Type: ```moveDirection = Input.GetAxis("Horizontal");```
        1. This code uses the GetAxis method within Input to assign a float value moveDirection based on the "Horizontal" Input received.
        2. **NOTE:** The Update Method runs every frame which means that it runs any code within this bracket every time the frame is refreshed.
    
    2. Type: ```rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);```
        1. Vector2 is a Unity Property that takes two float variables, x and y. We are applying moveDirection multipled by the moveSpeed to give us the horizontal velocity of the player based on the button pressed or our X value. Meanwhile y will be the current velocity of the rigid body basically implying that all this line is worried about is what the x value is doing.
