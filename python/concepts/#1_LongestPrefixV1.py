s = ["kk is iu",
     "kk isgdf",
     "kk isiurgdf",
     "kk is gsdfgdfg"
    ]

res = ""

temp = s[0]
for i in range(1, len(s)):
    for j in range(len(s[i])):
        try:
            if(s[i][j] == temp[j]):
                print(s[i][j])
                res += s[i][j]
                print(res)
            else:
                temp = res
                break
        except IndexError:
            continue 
        #print(s[i][j], temp[j])
print(temp)