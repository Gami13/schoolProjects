from django.shortcuts import render
from django.http import HttpResponse


def messages(request):
    return HttpResponse("Siema w aplikacji APP!")
