#arr that needs to be sorted
ArrBeforeSorting = [12, 233, 2, 0, 10, 15, 32, 78, 1, 2]

#create the hash map
value_count = {}
for num in ArrBeforeSorting:
    if num in value_count:
        value_count[num] += 1
    else:
        value_count[num] = 1
        
        
# create a new sorted array:
sorted_array = []
for num in sorted(value_count.keys()):
    sorted_array.extend([num] * value_count[num])
    
    
print(sorted_array)