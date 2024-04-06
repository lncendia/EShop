import {useFormik} from 'formik';
import * as Yup from 'yup';
import {Form, FormControl, Button} from 'react-bootstrap';

interface LoginFormProps {
    onSubmit: (email: string, password: string) => void;
}

const SignInForm = ({onSubmit}: LoginFormProps) => {

    const validationSchema = Yup.object().shape({
        email: Yup.string().email('Неверный формат email').required('Email обязателен для заполнения'),
        password: Yup.string().min(6, 'Пароль должен быть не менее 6 символов').required('Пароль обязателен для заполнения'),
    });

    const formik = useFormik({
        initialValues: {
            email: '',
            password: '',
        },
        validationSchema,
        onSubmit: (values) => {
            onSubmit(values.email, values.password);
        },
    });

    return (
        <Form onSubmit={formik.handleSubmit}>
            <Form.Group className="mb-3">
                <FormControl
                    placeholder="Логин"
                    name="email"
                    value={formik.values.email}
                    onChange={formik.handleChange}
                    isInvalid={formik.touched.email && !!formik.errors.email}
                />
                <FormControl.Feedback type="invalid">
                    {formik.errors.email}
                </FormControl.Feedback>
            </Form.Group>
            <Form.Group className="mb-3">
                <FormControl
                    placeholder="Пароль"
                    name="password"
                    type="password"
                    value={formik.values.password}
                    onChange={formik.handleChange}
                    isInvalid={formik.touched.password && !!formik.errors.password}
                />
                <FormControl.Feedback type="invalid">
                    {formik.errors.password}
                </FormControl.Feedback>
            </Form.Group>
            <Button variant="primary" type="submit">
                Войти
            </Button>
        </Form>
    );
};

export default SignInForm;
