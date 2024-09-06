#given an int n, return a  string array answer where:
# arr[i] == "fizzbuzz" if i is divisable by 3 and 5
# arr[i] == "fizzbuzz" if i is divisable by 3 
# arr[i] == "fizzbuzz" if i is divisable by  5
# arr[i] == i (as string) if none of the above


def fizzbuzz(lenght):
    arr = [0] * lenght
    
    for i in range(len(arr)):
        #arr[i] = f"{i+ 1}"  
        arr[i] = i + 1
        
        #int_array = [int(num) for num in arr]
        if arr[i] % 3 == 0 and arr[i] % 5 == 0:
            arr[i] = "fizzbuzz"
        elif arr[i] % 3 == 0:
            arr[i] = "fizz"
        elif arr[i] % 5 == 0:
            arr[i] = "buzz"
        else:
            arr[i] = f"{i + 1 }"
    
    return arr

if __name__ == "__main__":
    
    num = 3
    print(fizzbuzz(num))