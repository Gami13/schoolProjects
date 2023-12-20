from django.shortcuts import render
from django.http import HttpResponse
from django.contrib.auth.forms import AuthenticationForm


from django.shortcuts import redirect
from . import models
from django.urls import reverse
from django import contrib


def index(request):
    return render(request, "index.html")


def login(request):
    if request.method == 'POST':
        form = AuthenticationForm(request, request.POST)
        if form.is_valid():
            contrib.auth.login(request, form.get_user())
            contrib.messages.success(request, "Zalogowany :3")
            return redirect(reverse('index'))

    context = {'form': AuthenticationForm()}
    return render(request, 'login.html', context)


def logout(request):
    contrib.auth.logout(request)
    contrib.messages.info(request, "Wylogowany :3")
    return redirect(reverse('index'))


def messages(request):
    if request.method == 'POST':
        text = request.POST.get('text', '')
        if not 0 < len(text) <= 250:
            print("chuj")
            contrib.messages.error(
                request,
                "Wiadomość nie może być pusta, może mieć maks. 250 znaków!")
        else:
            print("chuj2")
            message = models.Message(
                message=text,
                user=request.user)
            message.save()
            return redirect(reverse('messages'))

    messages = models.Message.objects.all()
    context = {'messages': messages}
    return render(request, 'messages.html', context)
