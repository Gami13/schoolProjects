from django import urls
from django.urls import path
from . import views
from django.contrib.auth.forms import UserCreationForm
from django.views.generic.edit import CreateView
urlpatterns = [
    path('', views.index, name='index'),
    path('login/', views.login, name='login'),
    path('logout/', views.logout, name='logout'),
    path('messages/', views.messages, name='messages'),
    path('register/', CreateView.as_view(
        template_name='register.html',
        form_class=UserCreationForm,
        success_url=urls.reverse_lazy('index')
    ), name='register')
]
