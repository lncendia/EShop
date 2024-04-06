import {Button, Col, Form, Row} from "react-bootstrap";
import {useFormik} from "formik";
import {orderFormSchema} from "./OrderFormSchema.ts";
import FormSubtext from "../../../UI/FormSubtext/FormSubtext.tsx";

interface OrderFormProps {
    onSubmit: (
        name: string,
        phone: string,
        email: string,
        region: string,
        city: string,
        street: string,
        building: string,
        apartment?: string,
        comment?: string
    ) => void;
    email: string,
    name: string
}

const OrderForm = ({onSubmit, email, name}: OrderFormProps) => {
    const formik = useFormik({
        initialValues: {
            name: name,
            phone: '',
            email: email,
            region: '',
            city: '',
            street: '',
            building: '',
            apartment: '',
            comment: '',
        },
        validationSchema: orderFormSchema,
        onSubmit: (values) => {
            onSubmit(values.name, values.phone, values.email, values.region, values.city, values.street, values.building, values.apartment, values.comment);
        },
    });

    return (
        <Form onSubmit={formik.handleSubmit}>
            <Row className="gy-2 mb-3">
                <Col xs={12}>
                    <Form.Group>
                        <Form.Control
                            placeholder="Имя"
                            name="name"
                            value={formik.values.name}
                            onChange={formik.handleChange}
                            isInvalid={formik.touched.name && !!formik.errors.name}
                        />
                        <Form.Control.Feedback type="invalid">
                            {formik.errors.name}
                        </Form.Control.Feedback>
                    </Form.Group>
                </Col>
                <Col sm={6}>
                    <Form.Group>
                        <Form.Control
                            placeholder="Телефон"
                            name="phone"
                            type="tel"
                            value={formik.values.phone}
                            onChange={formik.handleChange}
                            isInvalid={formik.touched.phone && !!formik.errors.phone}
                        />
                        <Form.Control.Feedback type="invalid">
                            {formik.errors.phone}
                        </Form.Control.Feedback>
                    </Form.Group>
                </Col>
                <Col sm={6}>
                    <Form.Group>
                        <Form.Control
                            placeholder="Email"
                            name="email"
                            type="email"
                            value={formik.values.email}
                            onChange={formik.handleChange}
                            isInvalid={formik.touched.email && !!formik.errors.email}
                        />
                        <Form.Control.Feedback type="invalid">
                            {formik.errors.email}
                        </Form.Control.Feedback>
                    </Form.Group>
                </Col>
                <Col sm={6}>
                    <Form.Group>
                        <Form.Control
                            placeholder="Область"
                            name="region"
                            value={formik.values.region}
                            onChange={formik.handleChange}
                            isInvalid={formik.touched.region && !!formik.errors.region}
                        />
                        <Form.Control.Feedback type="invalid">
                            {formik.errors.region}
                        </Form.Control.Feedback>
                    </Form.Group>
                </Col>
                <Col sm={6}>
                    <Form.Group>
                        <Form.Control
                            placeholder="Город"
                            name="city"
                            value={formik.values.city}
                            onChange={formik.handleChange}
                            isInvalid={formik.touched.city && !!formik.errors.city}
                        />
                        <Form.Control.Feedback type="invalid">
                            {formik.errors.city}
                        </Form.Control.Feedback>
                    </Form.Group>
                </Col>
                <Col sm={4}>
                    <Form.Group>
                        <Form.Control
                            placeholder="Улица"
                            name="street"
                            value={formik.values.street}
                            onChange={formik.handleChange}
                            isInvalid={formik.touched.street &&
                                !!formik.errors.street}
                        />
                        <Form.Control.Feedback type="invalid">
                            {formik.errors.street}
                        </Form.Control.Feedback>
                    </Form.Group>
                </Col>
                <Col sm={4}>
                    <Form.Group>
                        <Form.Control
                            placeholder="Дом"
                            name="building"
                            value={formik.values.building}
                            onChange={formik.handleChange}
                            isInvalid={formik.touched.building && !!formik.errors.building}
                        />
                        <Form.Control.Feedback type="invalid">
                            {formik.errors.building}
                        </Form.Control.Feedback>
                    </Form.Group>
                </Col>
                <Col sm={4}>
                    <Form.Group>
                        <Form.Control
                            placeholder="Квартира"
                            name="apartment"
                            value={formik.values.apartment}
                            onChange={formik.handleChange}
                        />
                    </Form.Group>
                    <FormSubtext text="Можно оставить пустым"/>
                </Col>
                <Form.Group>
                    <Form.Control
                        as="textarea"
                        rows={2}
                        placeholder="Комментарий к заказу"
                        name="comment"
                        value={formik.values.comment}
                        onChange={formik.handleChange}
                    />
                    <FormSubtext text="Можно оставить пустым"/>
                </Form.Group>
            </Row>
            <Button variant="primary" type="submit">
                Подтвердить
            </Button>

        </Form>
    );
};
export default OrderForm;