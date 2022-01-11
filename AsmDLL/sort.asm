.code
i$ = 0
j$1 = 4
pivot$ = 8
t$2 = 12
t$ = 16
arr$ = 48
low1$ = 56
high1$ = 64
Sort proc
$LN7:
        mov     DWORD PTR [rsp+24], r8d
        mov     DWORD PTR [rsp+16], edx
        mov     QWORD PTR [rsp+8], rcx
        sub     rsp, 40                             ; 00000028H
        movsxd  rax, DWORD PTR high1$[rsp]
        mov     rcx, QWORD PTR arr$[rsp]
        mov     eax, DWORD PTR [rcx+rax*4]
        mov     DWORD PTR pivot$[rsp], eax
        mov     eax, DWORD PTR low1$[rsp]
        dec     eax
        mov     DWORD PTR i$[rsp], eax
        mov     eax, DWORD PTR low1$[rsp]
        mov     DWORD PTR j$1[rsp], eax
        jmp     SHORT $LN4@partition
$LN2@partition:
        mov     eax, DWORD PTR j$1[rsp]
        inc     eax
        mov     DWORD PTR j$1[rsp], eax
$LN4@partition:
        mov     eax, DWORD PTR high1$[rsp]
        dec     eax
        cmp     DWORD PTR j$1[rsp], eax
        jg      SHORT $LN3@partition
        movsxd  rax, DWORD PTR j$1[rsp]
        mov     rcx, QWORD PTR arr$[rsp]
        mov     edx, DWORD PTR pivot$[rsp]
        cmp     DWORD PTR [rcx+rax*4], edx
        jg      SHORT $LN5@partition
        mov     eax, DWORD PTR i$[rsp]
        inc     eax
        mov     DWORD PTR i$[rsp], eax
        movsxd  rax, DWORD PTR i$[rsp]
        mov     rcx, QWORD PTR arr$[rsp]
        mov     eax, DWORD PTR [rcx+rax*4]
        mov     DWORD PTR t$2[rsp], eax
        movsxd  rax, DWORD PTR j$1[rsp]
        movsxd  rcx, DWORD PTR i$[rsp]
        mov     rdx, QWORD PTR arr$[rsp]
        mov     r8, QWORD PTR arr$[rsp]
        mov     eax, DWORD PTR [r8+rax*4]
        mov     DWORD PTR [rdx+rcx*4], eax
        movsxd  rax, DWORD PTR j$1[rsp]
        mov     rcx, QWORD PTR arr$[rsp]
        mov     edx, DWORD PTR t$2[rsp]
        mov     DWORD PTR [rcx+rax*4], edx
$LN5@partition:
        jmp     SHORT $LN2@partition
$LN3@partition:
        mov     eax, DWORD PTR i$[rsp]
        inc     eax
        cdqe
        mov     rcx, QWORD PTR arr$[rsp]
        mov     eax, DWORD PTR [rcx+rax*4]
        mov     DWORD PTR t$[rsp], eax
        movsxd  rax, DWORD PTR high1$[rsp]
        mov     ecx, DWORD PTR i$[rsp]
        inc     ecx
        movsxd  rcx, ecx
        mov     rdx, QWORD PTR arr$[rsp]
        mov     r8, QWORD PTR arr$[rsp]
        mov     eax, DWORD PTR [r8+rax*4]
        mov     DWORD PTR [rdx+rcx*4], eax
        movsxd  rax, DWORD PTR high1$[rsp]
        mov     rcx, QWORD PTR arr$[rsp]
        mov     edx, DWORD PTR t$[rsp]
        mov     DWORD PTR [rcx+rax*4], edx
        mov     eax, DWORD PTR i$[rsp]
        inc     eax
        add     rsp, 40                             ; 00000028H
        ret     
Sort endp
end