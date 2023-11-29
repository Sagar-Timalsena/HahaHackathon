import csv

# Data to be written to the CSV file
data = [
    ["Parcel ID", "Owner Name", "Parcel Address City", "Parcel Address Zip Code", "First Alternative Parcel ID", "Second Alternative Parcel ID", "Parcel Use Code"],
    [123456789, "John Doe", "Trotwood", 45426, 987654321, 789654321, "Residential"],
    [234567890, "Jane Smith", "Trotwood", 45426, 876543210, 765432109, "Commercial"],
    [345678901, "Bob Johnson", "Trotwood", 45426, 765432109, 654321098, "Residential"],
    [456789012, "Alice Williams", "Trotwood", 45426, 654321098, 543210987, "Industrial"],
    [567890123, "Chris Davis", "Trotwood", 45426, 543210987, 432109876, "Commercial"]
]

# Specify the file name
file_name = "trotwood_data.csv"

# Writing to the CSV file
with open(file_name, mode='w', newline='') as file:
    writer = csv.writer(file)
    writer.writerows(data)

print(f"CSV file '{file_name}' has been generated.")
