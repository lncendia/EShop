import * as Yup from 'yup';

export const orderFormSchema = Yup.object().shape({
    name: Yup.string().required('Имя обязательно для заполнения'),
    phone: Yup.string().required('Телефон обязателен для заполнения'),
    email: Yup.string().email('Неверный формат email').required('Email обязателен для заполнения'),
    region: Yup.string().required('Область обязательна для заполнения'),
    city: Yup.string().required('Город обязателен для заполнения'),
    street: Yup.string().required('Улица обязательна для заполнения'),
    building: Yup.string().required('Дом обязателен для заполнения'),
    apartment: Yup.string(),
    comment: Yup.string(),
});
