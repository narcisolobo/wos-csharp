my_name = "Narciso"

print(my_name)

colors = ["blue", "red", "yellow"]

for color in colors:
    if color == "red":
        print("found the red one")
    elif color == "blue":
        print("found the blue one")
    else:
        print(color)

guitar = {"brand": "Fender", "model": "Stratocaster", "year": 1972, "is_new": False}

for key in guitar:
    print(guitar[key])

print(guitar)
