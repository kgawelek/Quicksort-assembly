.code
i = 0
j = 4
pivot = 8
t2 = 12
t = 16
arr = 48
low1 = 56
high1 = 64
Sort proc
start:
        mov     DWORD PTR [rsp+24], r8d             ; load argument - high1
        mov     DWORD PTR [rsp+16], edx             ; load argument - low1
        mov     QWORD PTR [rsp+8], rcx              ; load argument - arr 
        sub     rsp, 40                             ; 00000028H
        movsxd  rax, DWORD PTR high1[rsp]           ; reading high value to use it for pivot
        mov     rcx, QWORD PTR arr[rsp]             ; reading arr address
        mov     eax, DWORD PTR [rcx+rax*4]          ; loading value of arr[high] to eax which will be a pivot element
        mov     DWORD PTR pivot[rsp], eax           ; loading this value to pivot variable
        mov     eax, DWORD PTR low1[rsp]            ; reading low value
        dec     eax                                 ; decrementing low value
        mov     DWORD PTR i[rsp], eax               ; loading (low - 1) value to i variable
        mov     eax, DWORD PTR low1[rsp]            ; reading low value which will be used for loop
        mov     DWORD PTR j[rsp], eax               ; assigning this value to j variable which will be used in loop
        jmp     SHORT inside_loop
j_increment:                                        ; incrementing _loop counter (j)
        mov     eax, DWORD PTR j[rsp]               ; load j to registry
        inc     eax                                 ; increment
        mov     DWORD PTR j[rsp], eax               ; save to variable
inside_loop:                                        ; checking the loop condition - j =< high - 1
        mov     eax, DWORD PTR high1[rsp]           ; load high value to registy
        dec     eax                                 ; decrement its value
        cmp     DWORD PTR j[rsp], eax               ; compare j and high - 1
        jg      SHORT after_loop             ; if j > high - 1 end loop
        movsxd  rax, DWORD PTR j[rsp]               ; loading j value to registry
        mov     rcx, QWORD PTR arr[rsp]             ; loading arr value to registry
        mov     edx, DWORD PTR pivot[rsp]           ; loading pivot value to registry
        cmp     DWORD PTR [rcx+rax*4], edx          ; comparing arr[j] and pivot
        jg      SHORT continue_loop          ; jump to end of the loop iteration if arr[j] > pivot
        mov     eax, DWORD PTR i[rsp]               ; load i variable for incrementation
        inc     eax                                 ; increment i
        mov     DWORD PTR i[rsp], eax               ; save incremented value to variable
        movsxd  rax, DWORD PTR i[rsp]               ; read i value
        mov     rcx, QWORD PTR arr[rsp]             ; read arr value
        mov     eax, DWORD PTR [rcx+rax*4]          ; reading value of arr[i]
        mov     DWORD PTR t2[rsp], eax              ; saving value of arr[i] in temp variable used for swap
        movsxd  rax, DWORD PTR j[rsp]               ; read j value
        movsxd  rcx, DWORD PTR i[rsp]               ; read i value
        mov     rdx, QWORD PTR arr[rsp]             ; read arr value
        mov     eax, DWORD PTR [rdx+rax*4]          ; loading to eax value of arr[j] 
        mov     DWORD PTR [rdx+rcx*4], eax          ; arr[i] = arr[j]
        movsxd  rax, DWORD PTR j[rsp]               ; rad j value
        mov     rcx, QWORD PTR arr[rsp]             ; read arr 
        mov     edx, DWORD PTR t2[rsp]              ; read t value
        mov     DWORD PTR [rcx+rax*4], edx          ; arr[j] = t - end of swap
continue_loop:
        jmp     SHORT j_increment
after_loop:
        mov     eax, DWORD PTR i[rsp]               ; read i value
        inc     eax                                 ; increment i
        cdqe                                        ; load 32bit eax value to 64bit rax  
        mov     rcx, QWORD PTR arr[rsp]             ; read arr value
        mov     eax, DWORD PTR [rcx+rax*4]          ; read arr[i+1] value
        mov     DWORD PTR t[rsp], eax               ; save this value to t variable
        movsxd  rax, DWORD PTR high1[rsp]           ; read high value
        mov     ecx, DWORD PTR i[rsp]               ; read i vale 
        inc     ecx                                 ; increment to have i+1 value
        movsxd  rcx, ecx                            ; move 32bit ecx value to 64bit rcx
        mov     rdx, QWORD PTR arr[rsp]             ; read arr value
        mov     eax, DWORD PTR [rdx+rax*4]          ; load to eax value of arr[high]
        mov     DWORD PTR [rdx+rcx*4], eax          ; arr[i+1] = arr[high]
        movsxd  rax, DWORD PTR high1[rsp]           ; read high value
        mov     rcx, QWORD PTR arr[rsp]             ; read arr value
        mov     edx, DWORD PTR t[rsp]               ; read t value
        mov     DWORD PTR [rcx+rax*4], edx          ; arr[high] = t - end of swap
        mov     eax, DWORD PTR i[rsp]               ; load i value to return it from procedure
        inc     eax                                 ; increment this value
        add     rsp, 40                             ; 00000028H
        ret     
Sort endp
end